import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'ss-api-primer',
  templateUrl: './api-primer.component.html',
  styleUrls: ['./api-primer.component.css']
})
export class ApiPrimerComponent implements OnInit {

  maxHeight: number;

  constructor() { 
    this.maxHeight = window.innerHeight - 400
  }

  ngOnInit() {
  }

}
