import { ComponentFactoryResolver, Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router:Router,private toaster : ToastrService ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error =>
        { 
          if(error)
          {
          switch (error.status){
            case 400 :
              if(error.error.errors)
              {
                const modalStateErrors = [];
                for (var key in error.error.errors)
                {
                  if(error.error.errors[key])
                    modalStateErrors.push(error.error.errors[key]);
                }
                throw modalStateErrors.flat();
              }else
              {
                this.toaster.error(error.error,error.status);
              } 
             break;

             case 500 : 
               const navigationExtra:NavigationExtras = {state: error.error };
                this.router.navigateByUrl('/server-error',navigationExtra);
             break

             case 401 : 
               this.toaster.error(error.statusText,error.status) ;
             break;

             case 404 : 
               this.toaster.error(error.statusText,error.status); 
              break;
              
              default: 
              this.toaster.error('Something Wrong happened , please contact the Support team ');
              console.log(error.error);
            } 
                   
            return throwError(error)
          }
        }

    ));
  }
}
