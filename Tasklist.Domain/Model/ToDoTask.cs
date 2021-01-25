using System;
using Tasklist.Core.DataObjects;
using Tasklist.Domain.Enum;

namespace Tasklist.Domain.Model
{
    public class ToDoTask : Entity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public StatusEnum Status { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataEdicao { get; private set; }
        public DateTime? DataRemocao { get; private set; }
        public bool Ativo { get; private set; }

        public ToDoTask(string titulo, string descricao, bool ativo)
        {
            Titulo = titulo;
            Descricao = descricao;
            Ativo = ativo;

            Validar();
        }

        protected ToDoTask(){ }

        public void AdicionarDataEdicao() => DataEdicao = DateTime.Now;
        public void AdicionarDataCriacao() => DataCriacao = DateTime.Now;
        public void AdicionarRemocao() => DataRemocao = DateTime.Now;
        public void AtivarTask() => Ativo = true;
        public void DesativarTask() => Ativo = false;
        public void AdicionarTitulo(string titulo) => Titulo = titulo;
        public void CriarTaskStatus() => Status = StatusEnum.Pendente;
        public void FinalizarTaskStatus() => Status = StatusEnum.Concluido;
        public void AdicionarDescricao(string descricao)
        {
            Descricao = descricao;

        }
        public void Validar()
        {
            Validacoes.ValidarSeNullOuVazio(Titulo, "O título da task é obrigatório");
        }
    }
}
