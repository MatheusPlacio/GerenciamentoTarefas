export interface LoginRequest {
  usuario: string;
  senha: string;
}

export interface TokenResponse {
  token: string;
  expiresAt: Date;
}
