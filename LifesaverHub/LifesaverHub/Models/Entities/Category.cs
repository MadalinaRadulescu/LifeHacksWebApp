﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LifesaverHub.Models.Entities;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; }
}