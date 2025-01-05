import { SvgElementType } from "./svgElementType";

export class SvgElement {
    elementType: SvgElementType;
    x: number;
    y: number;
    x2: number | null;
    y2: number | null;
    r: number | null;
    width: number | null;
    height: number | null;
    fill: string | null;
    text: string | null;
    fontSize: number | null;
    fontWeight: string | null;
    stroke: string | null;
    strokeWidth: number | null;
}