using System;
using System.Collections.Generic;

#nullable disable

namespace crud.Models
{
    public partial class TvaleCc
    {
        public string Folio { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Saldo { get; set; }
        public string Motivo { get; set; }
        public decimal? NumEmp { get; set; }
        public decimal? NumEmpe { get; set; }
        public string NumReqSol { get; set; }
        public string CveEmpresa { get; set; }
        public string ChequeNo { get; set; }
        public long Id { get; set; }
    }
}
