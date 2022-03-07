namespace crud.Models.Response {

    public class Response {
        public int Estado {get; set;}
        public string message {get; set;}
        public object data {get; set;}

        public Response() {
            Estado = 0;
        }
    }
}