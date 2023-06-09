﻿using SendMail.Models.UserModels;

namespace SendMail.Models.ContactModels;

public class ReceiverContactDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User? User { get; set; }
}