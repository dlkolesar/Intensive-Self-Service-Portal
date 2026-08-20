import { Pipe, PipeTransform } from '@angular/core';
import { ServerData } from '../../../lib/account/server-data';


@Pipe({
  name: 'serverFilter'
})
export class ServerFilterPipe implements PipeTransform {

  transform(devices: ServerData[], args?: any): any {
    //console.log('[device-filter.pipe] filtering.......' + JSON.stringify(args));
    return devices.filter(dev => {
      let matchName;
      let matchDC;
      let matchTag;

      let match;
      
      dev.visible = false;
       //console.log('[device-filter.pipe] current server: ' + dev.name);


      //filter by DC
      if ((args.dc) && (args.dc.length > 0)) {
          matchDC = args.dc.indexOf(dev.dataCenter.toUpperCase()) > -1;
      }

      //filter by name
      if ((args.name) && (args.name.length > 0)) {
         // console.log('[device-filter.pipe] attempting to match ' + JSON.stringify(args.name.toLowerCase()));
          matchName = dev.name.toLowerCase().indexOf(args.name.toLowerCase()) > -1;
      }

      //filter by Tags(future)
      // if ((args.tags) && (args.tags.length > 0)) {
      //    //console.log('[device-filter.pipe] attempting to match ' + JSON.stringify(args.tags));
         
      //     var matchingTags: any[] = [];
      //     var arr:any[] = args.tags;

      //     arr.forEach(element => {
      //       var hasTag = dev.tags.findIndex(t=>t.id == element.id) > -1;
            
      //       if (hasTag){
      //         matchingTags.push(element);
      //       }
      //     });

      //     //console.log(matchingTags.length + ' of ' + args.tags.length + ' tag matches');
      //     matchTag = (matchingTags.length == args.tags.length);
      // }



      //combine matches
      if (matchDC == undefined) { matchDC = true };
      if (matchName == undefined) { matchName = true };
      if (matchTag == undefined) { matchTag = true };

      match = matchDC && matchName && matchTag;
      // console.log('[device-filter.pipe] matchDC: ' + JSON.stringify(matchDC));
      // console.log('[device-filter.pipe] matchName: ' + JSON.stringify(matchName));
      // console.log('[device-filter.pipe] matchTag: ' + JSON.stringify(matchTag));
      // console.log('[device-filter.pipe] match: ' + JSON.stringify(match));
      // console.log('');
      dev.visible = match;  //show/hide this device in the list
      return match;
    });
  }

}
