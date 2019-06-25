using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities;
using Entities.Models;

namespace Entities.ExtendedModels
{
    public class OwnerExtended:IEntity
    {
        //TODO why not exted Owner Class
        //   [Key]
        //   [Column("OwnerId")]
        public Guid Id { get; set; }

        //   [Required(ErrorMessage = "Name is required")]
        //   [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        //   [Required(ErrorMessage = "Date of birth required")]
        public DateTime DateOfBirth { get; set; }

        //  [Required(ErrorMessage = "Address is required")]
        //  [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string Address { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        public OwnerExtended()
        {

        }

        public OwnerExtended(Owner owner)
        {
            Id = owner.Id;
            Name = owner.Name;
            DateOfBirth = owner.DateOfBirth;
            Address = owner.Address;
        }
    }
}
