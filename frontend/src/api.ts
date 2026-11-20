// Stand-in for real sign-in: every request is made as this synthetic tenant (see backend SeedData).
export const DEMO_TENANT_ID = '11111111-1111-1111-1111-111111111111'

export function apiFetch(path: string, init?: RequestInit) {
  return fetch(path, {
    ...init,
    headers: { ...init?.headers, 'X-Tenant-Id': DEMO_TENANT_ID },
  })
}
