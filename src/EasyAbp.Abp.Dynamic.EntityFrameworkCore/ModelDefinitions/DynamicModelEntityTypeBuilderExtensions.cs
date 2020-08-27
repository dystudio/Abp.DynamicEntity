﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public static class DynamicModelEntityTypeBuilderExtensions
    {
        public static void ConfigureDynamicModel<T>(this EntityTypeBuilder<T> b)
            where T : class, IDynamicModel
        {
            b.HasOne(e => e.ModelDefinition)
                .WithMany()
                .HasForeignKey(x => x.ModelDefinitionId)
                .OnDelete(DeleteBehavior.SetNull)
                ;
        }
    }
}