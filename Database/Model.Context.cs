﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConstructorEntities : DbContext
    {
        public ConstructorEntities()
            : base("name=ConstructorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Questionnaire> Questionnaires { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
    }
}