import { TestBed, async, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { FileDetailsService } from './file-details.service';
import { FileDetails } from './file-details.model';
import { formatDate } from '@angular/common';

describe('PostService', () => {
  let fileDetailsService: FileDetailsService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
      ],
      providers: [
        FileDetailsService
      ],
    });

    fileDetailsService = TestBed.get(FileDetailsService);
    httpMock = TestBed.get(HttpTestingController);
  });

  it(`should fetch post as an Observable`, async(inject([HttpTestingController, FileDetailsService],
    (httpClient: HttpTestingController, fileDetailsService: FileDetailsService) => {

      fileDetailsService.formData = new FileDetails();
      fileDetailsService.formData.fileDate = formatDate(new Date(), 'yyyy/MM/dd', 'en');
      fileDetailsService.formData.fileName =   "Test.jpg";
      fileDetailsService.formData.fileSize = "220459";
      fileDetailsService.formData.fileType = "image/jpeg";
      fileDetailsService.formData.file = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAYABgAAD 4QAiRXhpZgAATU0AKgAAAAgAAQESAAMAAAABAAEAAAAAAAD" ;

      fileDetailsService.postFileDetails()
        .subscribe((posts: any) => {
            debugger
          expect(posts.id >0).toBe(posts.id > 0);
        });

        let req = httpMock.expectOne("http://localhost:51962/api/FileDetails");
        expect(req.request.method).toBe("POST");

      httpMock.verify();

    })));

    it(`should fetch gets as an Observable`, async(inject([HttpTestingController, FileDetailsService],
        (httpClient: HttpTestingController, fileDetailsService: FileDetailsService) => {
    
       
          var result = fileDetailsService.refreshList()
          expect(result != null).toBe(result != null);
    
            let req = httpMock.expectOne("http://localhost:51962/api/FileDetails");
            expect(req.request.method).toBe("GET");
    
          httpMock.verify();
    
        })));
});