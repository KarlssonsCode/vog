// const RAWG_API_KEY = '2d3aad5dadc942bfa3ec90918afaaa10';
// const RAWG_API_URL = 'https://api.rawg.io/api/';

export interface RawgGame {
  id: number;
  name: string;
  released: string;
  background_image: string;
  rating: number;
  metacritic: number;
}
