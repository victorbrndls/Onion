﻿using Microsoft.EntityFrameworkCore;
using Onion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.DAL
{
    public class ProjetoDAO
    {
        private readonly Context _context;
        public ProjetoDAO(Context context) => _context = context;

        public void Cadastrar(Projeto projeto)
        {
            Alterar(projeto);
        }
        public void Alterar(Projeto projeto)
        {
            _context.Projetos.Update(projeto);
            _context.SaveChanges();
        }
        public void Deletar(int IdProjeto)
        {
            _context.Projetos.Remove(Buscar(IdProjeto));
            _context.SaveChanges();
        }
        public List<Projeto> Listar()
        {
            return _context.ProjetoDoUsuarios
                .Include(p => p.Projeto)
                .ThenInclude(p => p.Tarefas)
                .Select(p => p.Projeto)
                .ToList();
        }

        public List<Projeto> Listar(int IdUsuario)
        {
            return _context.ProjetoDoUsuarios.
                Where(p => p.UsuarioId == IdUsuario)
                .Include(p => p.Projeto)
                .ThenInclude(p => p.Tarefas)
                .Select(p => p.Projeto)
                .ToList();
        }

        public Projeto Buscar(int id) =>
            _context.Projetos
            .Where(p => p.Id == id)
            .Include(p => p.Tarefas)
            .ToList().First();

    }
}
