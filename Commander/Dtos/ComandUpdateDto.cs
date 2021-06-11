using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    //se usa la notacion de datos para validar
    //cuando se envia al api la data incompleta 
    //como resultado devolvera un 400

    //NOTA PARA MI: NUNCA RETORNES UN 500
    public class CommandUpdateDto 
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}