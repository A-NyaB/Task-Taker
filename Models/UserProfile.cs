﻿using System.ComponentModel.DataAnnotations;


namespace Task_Taker.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string DisplayName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(555)]
        public string Email { get; set; }

        public DateTime CreateDateTime { get; set; }

        [DataType(DataType.Url)]
        [MaxLength(255)]
        public string ImageLocation { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}

