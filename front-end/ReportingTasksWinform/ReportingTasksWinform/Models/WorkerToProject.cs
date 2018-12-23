﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Models
{
    public class WorkerToProject
    {
        [Required]
        public int WorkerToProjectId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public int Hours { get; set; }
    }
}
