﻿using CaseMgmtAPI.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace CaseMgmtAPI.Features.Cases.DTO
{
    public class CaseDTO
    {
        [Required]
        public Child? Child { get; set; }
        [Required]
        public Reporter? Reporter { get; set; }
    }
}