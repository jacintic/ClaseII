import { Timestamp } from "rxjs";

export interface Book {
  id: number;
  title: string;
  isbn?: string;
  releaseYear?: number;
  description?: string;
  price?: number;
  // associations
  categories?: any[];
  author?: any;
  // foreign keys
  authorId?: number;
}
