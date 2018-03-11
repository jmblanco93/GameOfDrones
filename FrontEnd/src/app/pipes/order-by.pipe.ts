import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'orderBy'
})
export class OrderByPipe implements PipeTransform {

  transform(array: Array<any>, property: string, asc: boolean = true): any {
    array.sort((a: any, b: any) => {
      if (asc) {
        if (a[property] < b[property]) {
          return -1;
        } else if (a[property] > b[property]) {
          return 1;
        } else {
          return 0;
        }
      } else {
        if (a[property] < b[property]) {
          return 1;
        } else if (a[property] > b[property]) {
          return -1;
        } else {
          return 0;
        }
      }
    });
    return array;
  }
}
