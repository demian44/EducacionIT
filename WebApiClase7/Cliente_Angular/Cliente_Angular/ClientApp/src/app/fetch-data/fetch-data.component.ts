import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public amigos: Persona[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
    http.get<Persona[]>('http://localhost:3606/api/Personas/Getamigos').subscribe(result => {
      console.log(result);
      this.amigos = result;
    }, error => console.error(error));
  }
}

interface Persona {
  id: number;
  apellido: string;
  nombre: string

}
