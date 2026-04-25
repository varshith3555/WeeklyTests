import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ReactiveFormsModule, NonNullableFormBuilder, Validators } from '@angular/forms';
import { Subject, switchMap, startWith, shareReplay, finalize } from 'rxjs';
import { CourseService } from './course.service';
import { Course } from './course.models';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  private readonly fb = inject(NonNullableFormBuilder);
  private readonly courseService = inject(CourseService);

  private readonly refresh$ = new Subject<void>();
  readonly courses$ = this.refresh$.pipe(
    startWith(undefined),
    switchMap(() => this.courseService.getCourses()),
    shareReplay({ bufferSize: 1, refCount: true })
  );

  readonly form = this.fb.group({
    title: this.fb.control('', [Validators.required]),
    instructor: this.fb.control('', [Validators.required]),
    duration: this.fb.control(1, [Validators.required, Validators.min(1)])
  });

  isSaving = false;
  errorMessage: string | null = null;

  trackById(_index: number, course: Course): number {
    return course.id;
  }

  addCourse(): void {
    this.errorMessage = null;

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const request = this.form.getRawValue();
    this.isSaving = true;

    this.courseService
      .addCourse(request)
      .pipe(finalize(() => (this.isSaving = false)))
      .subscribe({
        next: () => {
          this.form.reset({ title: '', instructor: '', duration: 1 });
          this.refresh$.next();
        },
        error: () => {
          this.errorMessage = 'Failed to add course.';
        }
      });
  }

  deleteCourse(id: number): void {
    this.errorMessage = null;

    this.courseService.deleteCourse(id).subscribe({
      next: () => this.refresh$.next(),
      error: () => {
        this.errorMessage = 'Failed to delete course.';
      }
    });
  }
}
