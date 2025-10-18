using System;
using System.Collections.Generic;

namespace DPA.Practica0122102067.CORE.Core.Entities;

public partial class Estudiante
{
    public int Id { get; set; }

    public string Paterno { get; set; } = null!;

    public string Materno { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Correo { get; set; } = null!;

    public int CarreraId { get; set; }

    public virtual Carrera Carrera { get; set; } = null!;
}
