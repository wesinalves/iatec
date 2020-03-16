import { EventModel } from './events-list/event.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'; 

@Injectable({
  providedIn: 'root'
})
export class EventService {
  
  eventsUrl = "https://localhost:5001/api/Event/";
  constructor(private http: HttpClient) { }

  list(){
    return this.http.get<any[]>(`${this.eventsUrl}`);
  }

  select(id: any){
    return this.http.get<any>(`${this.eventsUrl}`.concat(id));
  }

  save(event: EventModel): Observable<any>{
    return this.http.post(`${this.eventsUrl}`, event);
  }

  update(id: any, event: EventModel): Observable<any>{
    return this.http.put(`${this.eventsUrl}`.concat(id), event);
  }

  delete(id: any){
    return this.http.delete(`${this.eventsUrl}`.concat(id));
  }
}
