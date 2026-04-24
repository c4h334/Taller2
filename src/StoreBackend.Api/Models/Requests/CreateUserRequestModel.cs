using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Models.Requests;

public class CreateUserRequestModel
{
    public Guid? ExternalId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
}