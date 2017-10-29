﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception InnerException)
            : base("Error al acceder al archivo: " + InnerException.Message)
        {
        }
    }
}
