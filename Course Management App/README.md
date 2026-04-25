# Course Management App (Angular 17 + RxJS + .NET Core API)

## Backend (.NET API)

From `CourseManagement.Api/`:

- Run: `dotnet run --launch-profile http`
- API base URL: `http://localhost:5025`

Endpoints:
- `GET /api/courses` (display)
- `POST /api/courses` (add)
- `DELETE /api/courses/{id}` (delete)

Model:
- `Course`: `Id`, `Title`, `Instructor`, `Duration`

## Frontend (Angular 17)

From `course-management-ui/`:

- Run: `npm start`
- App URL: `http://localhost:4200`

The UI uses `HttpClient` + RxJS to load courses and refresh the list after add/delete.

## Notes

- CORS is enabled on the API for `http://localhost:4200`.
- The API uses an in-memory store (data resets on restart).
