import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { Constantes } from '../Util/Constantes';

@Pipe({
  name: 'DateTimeFormatPiper'
})
export class DateTimeFormatPiperPipe extends DatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return super.transform(value, Constantes.DATE_TIME_FMT);
  }
}
