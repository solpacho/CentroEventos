using Aplicacion;
using System;

        try
        {
            // Simulo entrada del usuario
            Console.WriteLine("Ingrese DNI:");
            string? dni = Console.ReadLine();

            Console.WriteLine("Ingrese nombre:");
            string? nombre = Console.ReadLine();

            Console.WriteLine("Ingrese apellido:");
            string? apellido = Console.ReadLine();

            Console.WriteLine("Ingrese email:");
            string? email = Console.ReadLine();

            Console.WriteLine("Ingrese teléfono:");
            string? telefono = Console.ReadLine();

            // Validación: clase estática para respetar arquitectura limpia
            ValidadorPersona.Validar(dni, nombre, apellido, email);

            // Si todo es válido, se crea la persona
            Persona p = new Persona(dni, nombre, apellido, email, telefono);

            Console.WriteLine("Persona creada exitosamente.");
        }
        catch (Exception ex)
        {
            // Si falla, se informa el error
            Console.WriteLine($"Error al crear persona: {ex.Message}");
        }

// la variable persona debe crearse antes del try-catch porque sino es inaccesible fuera
    