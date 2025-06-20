using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TweetsApi.Models;

public class Tweet
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}