import { add } from "lodash";

export function addNumbers(left: number, right: number): number {
  return add(left, right);
}

export function sayHello(name: string): string {
  return `Hello from TypeScript, ${name}!`;
}
