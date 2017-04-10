using System.ComponentModel.DataAnnotations;

namespace EventManagement.DataModels
{
    public class VenueDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "Not a valid Phone number")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Your must provide a EmailId")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Address { get; set; }
        public MapDTO Map { get; set; }
    }
}
