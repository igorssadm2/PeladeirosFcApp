"use client";

import { createUser, User } from "@/lib/api";
import { useState } from "react";

export function UserForm() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setLoading(true);
    setError(null);

    try {
      const userData: Partial<User> = {
        userName: "joao_silva",
        email: "joao@example.com",
        normalizedUserName: "JOAO_SILVA",
        normalizedEmail: "JOAO@EXAMPLE.COM",
        emailConfirmed: false,
        passwordHash: "hash_do_password",
        securityStamp: "stamp_123",
        concurrencyStamp: "concurrency_123",
        phoneNumber: "11999999999",
        phoneNumberConfirmed: false,
        twoFactorEnabled: false,
        lockoutEnabled: false,
        accessFailedCount: 0,
        apelido: "João",
        dataNascimento: "1990-05-15T00:00:00Z",
        genero: "M",
        fotoUrl: "https://example.com/foto.jpg",
        cidade: "São Paulo",
        bairro: "Vila Mariana",
        cep: "04015-030",
        altura: 180,
        peso: 75,
        tamanhoPe: 42,
        peDominante: "direito",
        posicao: "Atacante",
        dataCriacao: new Date().toISOString(),
        dataAtualizacao: new Date().toISOString(),
      };

      const response = await createUser(userData);
      console.log("User created successfully:", response);
      alert("Usuário criado com sucesso!");
    } catch (err) {
      const errorMessage =
        err instanceof Error ? err.message : "Erro ao criar usuário";
      setError(errorMessage);
      console.error("Error:", err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="w-full max-w-md mx-auto p-6">
      <h2 className="text-2xl font-bold mb-4">Criar Novo Usuário</h2>

      {error && (
        <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded mb-4">
          {error}
        </div>
      )}

      <form onSubmit={handleSubmit}>
        <button
          type="submit"
          disabled={loading}
          className="w-full bg-blue-600 hover:bg-blue-700 disabled:bg-gray-400 text-white font-bold py-2 px-4 rounded"
        >
          {loading ? "Enviando..." : "Criar Usuário"}
        </button>
      </form>
    </div>
  );
}
