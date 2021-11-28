﻿using System;
using Data.Common;

namespace Data
{
    public class RoleAssignmentData : BaseEntityData
    {
        public string personId {  get; set; }
        public string roleId { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime validTo { get; set; }

    }
}