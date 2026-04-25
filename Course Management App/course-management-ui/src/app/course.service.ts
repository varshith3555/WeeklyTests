import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from './api-base-url';
import { Course, CourseCreateRequest } from './course.models';

@Injectable({ providedIn: 'root' })
export class CourseService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = inject(API_BASE_URL);

  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(`${this.baseUrl}/api/courses`);
  }

  addCourse(request: CourseCreateRequest): Observable<Course> {
    return this.http.post<Course>(`${this.baseUrl}/api/courses`, request);
  }

  deleteCourse(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/api/courses/${id}`);
  }
}
