terraform {
  required_version = ">= 1.0.0"

  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 4.0"
    }
  }
}

provider "aws" {
  region     = "us-east-2"
  access_key = "XXXXXXXXXXXXX"
  secret_key = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
}

# Crear un KeyPair
resource "aws_lightsail_key_pair" "rcorona01" {
  name = "mi-key-pair"  # Nombre del KeyPair
}

# Guardar la clave privada en un archivo
resource "local_file" "private_key" {
  content  = aws_lightsail_key_pair.rcorona01.private_key
  filename = "${path.module}/mi-key-pair.pem"  # Nombre del archivo donde se guardará la clave privada
}

# Crear una instancia de Lightsail con Ubuntu 20.04 y el plan nano con soporte IPv6
resource "aws_lightsail_instance" "rcorona01" {
  name              = "server-pruebas"
  availability_zone = "us-east-2a"
  blueprint_id      = "ubuntu_24_04"  # Usar Ubuntu 20.04
  bundle_id         = "small_3_0" # Usar el plan nano con soporte IPv6
  key_pair_name     = aws_lightsail_key_pair.rcorona01.name  # Usar el KeyPair creado
}

# Abrir los puertos 22, 80 y 8080 en la instancia y permitir tráfico desde cualquier IPv6
resource "aws_lightsail_instance_public_ports" "rcorona01" {
  instance_name = aws_lightsail_instance.rcorona01.name

  # Regla para el puerto 22 (SSH)
  port_info {
    protocol  = "tcp"
    from_port = 22
    to_port   = 22    
  }

  # Regla para el puerto hhtps (Alternativo)
  port_info {
    protocol  = "tcp"
    from_port = 80
    to_port   = 80    
  }
}

# Mostrar la dirección IPv6 de la instancia
output "ipv6_address" {
  value = aws_lightsail_instance.rcorona01.public_ip_address
}

# Mostrar el nombre del KeyPair
output "key_pair_name" {
  value = aws_lightsail_key_pair.rcorona01.name
}


resource "null_resource" "rcorona01" {
  # Ejecutar comandos después de crear la instancia
  provisioner "remote-exec" {
    inline = [
      "sudo apt update -y",    # Actualizar la lista de paquetes
      "sudo snap install dotnet-sdk --classic", # Se habilita dotnet para ejecutar el api
      "git clone https://github.com/roco170a/webapi-productos.git" # Se le valida el repo
    ]

    # Configuración de la conexión SSH
    connection {
      type        = "ssh"
      user        = "ubuntu"  # Usuario por defecto en Ubuntu
      private_key = aws_lightsail_key_pair.rcorona01.private_key
      host        = aws_lightsail_instance.rcorona01.public_ip_address
    }
  }
}