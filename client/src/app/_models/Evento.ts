import { Lote } from './Lote';
import {RedeSocial} from './RedeSocial';
import { Palestrante } from './Palestrante';

export interface Evento {
  id: number;
  local: string;
  data: Date;
  tema: string;
  qttPessoas: number;
  img: string;
  telefone: string;
  email: string;

  lotes:Lote[];
  redesSociais:RedeSocial[];
  palestrantes: Palestrante[];
}
