import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Observable, Subscription } from "rxjs";
import { IntervalObservable } from "rxjs/observable/IntervalObservable";
import 'rxjs/add/operator/takeWhile';

import { MatDialog, MatDialogRef, MatDialogConfig } from '@angular/material';

import { CachingService } from '../../../lib/caching';
import { WinPatchService } from '../../win-patch.service';
import { TicketGeneratorConfiguration } from '../../models/ticket-generator-configuration';
import { ErrorDialog } from '../../../lib/error-dialog';
import { ProgressBarDialog } from '../../../lib/progress-bar-dialog';

@Component({
  selector: 'app-ticket-generator-config',
  templateUrl: './ticket-generator-config.component.html',
  styleUrls: ['./ticket-generator-config.component.css']
})
export class TicketGeneratorConfigComponent implements OnInit {
  config: TicketGeneratorConfiguration;

  errorDialog: ErrorDialog;
  progressDialog: ProgressBarDialog;
  contentHeight: number;

  constructor(private router: Router, 
    private route: ActivatedRoute,
    private cache: CachingService,
    private ticketGenerator: WinPatchService,
    private dlgError: MatDialog,
    private dlgProgress: MatDialog,) {

      this.errorDialog = new ErrorDialog(this.dlgError);
      this.progressDialog = new ProgressBarDialog(this.dlgProgress);
      this.cache.hideAccount();

}

  ngOnInit() {
    this.contentHeight = window.innerHeight - 320; 
    this.progressDialog.open("Ticket Generator", "indeterminate");
    this.progressDialog.updateProgress(-1, "Loading config....");
    this.ticketGenerator.getTicketGeneratorConfig()
                  .subscribe(cfg => {
                    this.config = cfg;
                  },
                  err => {
                    this.errorDialog.showError("Ticket Generator", err, '', 'error');
                  },
                  () =>{
                    this.progressDialog.close();
                  }
                );
  }


  OnSubmit(){
    this.progressDialog.open("Ticket Generator", "indeterminate");
    this.progressDialog.updateProgress(-1, "Saving config....");
    this.ticketGenerator.saveTicketGeneratorConfig(this.config)
        .subscribe(cfg => {
        
        },
        err => {
          this.errorDialog.showError("Ticket Generator", err, '', 'error');
        },
        () =>{
          this.progressDialog.close();
        }
      );
  }
}





