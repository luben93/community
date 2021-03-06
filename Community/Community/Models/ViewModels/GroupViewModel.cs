﻿using Community.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Community.ViewModels
{
    /// <summary>
    /// Viewmodel for groups
    /// </summary>
    public class GroupViewModel
    {
        /// <summary>
        /// Group id
        /// </summary>
        [Key]
        public int Id { get; set; } // Id for Entity Framework and database

        /// <summary>
        /// Group name
        /// </summary>
        [Required]
        [MinLength(3, ErrorMessage = "Group name must be at least 3 characters long")]
        [MaxLength(100, ErrorMessage="Group name cannot be longer than 100 characters")]
        [RegularExpression(@"^[a-zåäöA-ZÅÄÖ0-9''-'\s]{1,40}$", ErrorMessage =
            "Only swedish letters, numbers, and blank spaces are allowed in group name")]
        public string Name{ get; set; }

        /// <summary>
        /// Group description
        /// </summary>
        [MaxLength(5000)]
        public string Description { get; set; }

        /// <summary>
        /// Group members
        /// </summary>
        public List<String> Members { get; set; }

        /// <summary>
        /// Boolean for whether current user is member of group or not
        /// </summary>
        public Boolean isMember { get; set; }

        /// <summary>
        /// Boolean for whether current user is owner of group or not
        /// </summary>
        public Boolean isOwner { get; set; }

        public GroupViewModel()
        {

        }

        public GroupViewModel(Group group)
        {
            this.isOwner = false;
            this.isMember = false;
            this.Name = group.Name;
            this.Description = group.Description;
            this.Members = new List<string>();
            this.Id = group.Id;
            foreach (ApplicationUser user in group.Members)
            {
                Members.Add(user.Email);
            }
        }
    }
}