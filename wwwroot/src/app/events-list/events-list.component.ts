import { EventService } from './../event.service';
import { Component, OnInit } from '@angular/core';
import { EventModel } from './event.model';
import * as _ from 'lodash';


@Component({
  selector: 'app-events-list',
  templateUrl: './events-list.component.html',
  styleUrls: ['./events-list.component.sass']
})
export class EventsListComponent implements OnInit {
  
  events: Array<any>;
  event: EventModel = new EventModel();
  update: boolean;
  filteredEvents: Array<any>;
  
  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.list();
  }

  list(){
    this.eventService.list().subscribe(data => 
      {
        this.events = _.clone(data)
        this.filteredEvents = data
      });
  }

  saveEvent(){
    this.event.userId = 1
    this.eventService.save(this.event).subscribe(event => {
      this.event = new EventModel();
      this.list();    
    }, 
      err => {console.log('erro ao cadastrar evento', err)});
  }

  selectEvent(id: number){
    
    this.update = true
    this.eventService.select(id).subscribe(event => {
      this.event = event;
    },
      err => {console.log('erro ao selecionar evento')});

  }

  updateEvent(id: number){
    this.event.userId = 1;
    this.eventService.update(id, this.event).subscribe(event => {
      this.event = new EventModel();
      this.list();
      this.update = false;    
    }, 
      err => {console.log('erro ao atualizar evento', err)});
  }

  removeEvent(id: number){
    this.event.userId = 1;
    this.eventService.delete(id).subscribe(event => {
      this.event = new EventModel();
      this.list();    
    }, 
      err => {console.log('erro ao atualizar evento', err)});
  }

  search(ev: any){
    let serVal = ev.target.value;
    if(serVal && serVal.trim() != ''){
      this.filteredEvents = this.events.filter((a) => {
        return (a.startDate.toLowerCase().indexOf(serVal.toLowerCase()) > -1);
      })
    }
  }

  clear(){
    this.filteredEvents = _.clone(this.events)
  }

}
