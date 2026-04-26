using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBackend.Domain.Entities;
[Table("User")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public Guid ExternalId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [MaxLength(256)]
    public string PasswordHash { get; set; }
}