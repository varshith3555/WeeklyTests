export interface Course {
  id: number;
  title: string;
  instructor: string;
  duration: number; // in hours
}

export interface CourseCreateRequest {
  title: string;
  instructor: string;
  duration: number; // in hours
}
