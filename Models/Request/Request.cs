namespace crud.Models.Request {

    public class Request {
         public long id {get; set;}
         public string folio {get;set;}
         public string fecha {get; set;}
         public float monto {get; set;}
         public float saldo {get; set;}
         public string motivo {get; set;}
        public int num_emp {get; set;}
        public int num_empe {get; set;}
        public string num_req_sol {get; set;}
        public string cve_empresa {get; set;}
        public string cheque_no {get; set;}
    }

}