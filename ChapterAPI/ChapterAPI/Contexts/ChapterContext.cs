﻿using ChapterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChapterAPI.Contexts
{
    public class ChapterContext: DbContext
    {
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions<ChapterContext>options): base(options)
        {
        }
        // vamos utilizar esse método para configurar o banco de dados
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação
            optionsBuilder.UseSqlServer("Data Source = LAPTOP-011IHATC\\SQLEXPRESS; initial catalog = Chapter;Integrated Security = true"); // caso com senha Id User = sa;password = XXX
            }
        }
        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
        public DbSet<Livro> Livros { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
