﻿using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Interface.ChildInterface
{
    public interface IGroupeEtudiantService
    {
        Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllGroupForStudent(string id);
    }
}
