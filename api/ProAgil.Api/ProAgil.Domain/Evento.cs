using System;
using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public string Tema { get; set; }
        public int QttPessoas { get; set; }
        public string Img { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public List<Lote> Lotes { get; set; }
        public List<RedesSociais> RedesSociais { get; set; }
        public List<PalestranteEvento> PalestranteEventos { get; set; }
    }
}