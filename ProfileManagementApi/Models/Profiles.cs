﻿using System;
using System.Collections.Generic;

namespace ProfileManagementApi.Models
{
    public class Profiles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProfilePhoto { get; set; }
        public DateTime CreatedAt{ get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Projects> Type { get; set; }
    }
}