﻿using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public List<ContatoModel> BuscarTodos(int usuarioID)
        {
            return _bancoContext.Contatos.Where(x => x.UsuarioID == usuarioID).ToList(); //ta carregando tudo que ta no banco de dados
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            // gravar no banco de dados

            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges(); //e como se fosse uma confirmação
            return contato;
        }

        public ContatoModel ListarPorID(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorID(contato.Id);
            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            contatoDB.Name = contato.Name;
            contatoDB.Email = contato.Email;
            contatoDB.Celular= contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;

        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorID(id);
            if (contatoDB == null) throw new System.Exception("Houve um erro na deleção do contato!");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
