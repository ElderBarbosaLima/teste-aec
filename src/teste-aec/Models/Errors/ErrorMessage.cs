using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestAec.Models.Errors;
public record ErrorMessage
{
    public ErrorMessage(string message)
    {
        Message = message;
        CreateOn = DateTime.Now;
    }
    [JsonIgnore]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }
    public string Message { get; set; }
    [JsonIgnore]
    public DateTimeOffset CreateOn { get; set; }
}
