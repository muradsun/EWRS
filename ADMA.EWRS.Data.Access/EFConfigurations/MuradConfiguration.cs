﻿using ADMA.EWRS.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Access.EFConfigurations
{
    public class MuradConfiguration : EntityTypeConfiguration<Murad>
    {
        public MuradConfiguration()
        {
            Property(c => c.ID)
                .IsRequired();

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(500);

            ToTable("Murad", "Test");

        }
    }
}
