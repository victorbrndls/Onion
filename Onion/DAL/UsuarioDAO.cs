﻿using Onion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.DAL
{
    public class UsuarioDAO
    {
        private readonly Context _context;
        public UsuarioDAO(Context context) => _context = context;

        public UsuarioView BuscarPorNome(string Nome)
        {
            return _context.Usuarios.Where(u => u.Nome == Nome).First();
        }

        public void Atualizar(UsuarioView usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

    }
}
