//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CCL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Respuestos
    {
        public int idRepuesto { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public Nullable<int> idActivo { get; set; }
        public Nullable<int> idTiporepuesto { get; set; }
    
        public virtual Activos Activos { get; set; }
        public virtual TipoRepuesto TipoRepuesto { get; set; }
    }
}
