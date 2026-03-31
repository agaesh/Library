<template>
    <div class="table-wrapper">
        <table class="list-table">
            <thead>
                <tr>
                    <th>
                        <input type="checkbox"
                               :checked="selectAll"
                               @change="toggleSelectAll" />
                    </th>
                    <th v-for="(header, i) in headers" :key="i">
                        {{ header }}
                    </th>
                    <th class="action-header" v-if="rows.length > 0">Actions</th>
                </tr>
            </thead>

            <tbody>

                <tr v-for="(row, index) in rows" :key="index">
                    <td>
                        <input type="checkbox"
                               :value="row.id"
                               v-model="selectedRows" />
                    </td>

                    <td v-for="(header, i) in headers" :key="i">
                        <div v-if="header === '#'">
                            {{row.id}}
                        </div>

                        <div v-if="header === 'cover'" class="book-cover">
                            <img :src="row.cover" alt="Book Cover" />
                        </div>


                        <div v-if="header === 'Name'" class="book-stack">
                            <div class="book-title clamp">{{ row.name }}</div>
                            <div class="book-meta">
                                <span class="author">{{ row.author }}</span>
                                <span class="genre">{{ row.genre }}</span>
                            </div>
                            <div class="book-isbn">ISBN: {{ row.isbn }}</div>
                        </div>

                        <!-- Status column -->
                        <span v-else-if="header.toLowerCase() === 'status'"
                              class="status-badge"
                              :class="row[header.toLowerCase()].toLowerCase() === 'active' ? 'active' : 'inactive'">
                            {{ row[header.toLowerCase()] }}
                        </span>

                        <div v-else-if="header.toLowerCase() === 'created'">
                            {{ row[header.toLowerCase()] }}
                        </div>
                    </td>

                    <!-- Desktop view: inline buttons -->
                    <td class="action-cell" v-if="rows.length > 0">
                        <button class="btn btn-warning" @click="$emit('edit', row)">
                            <i class="fas fa-edit"></i>
                        </button>
                        <button class="btn btn-danger" @click="$emit('delete', row)">
                            <i class="fas fa-trash-alt"></i>
                        </button>
                        <button class="btn btn-primary" @click="$emit('assign',row)">
                            <i class="fas fa-handshake"></i>
                        </button>
                        <button class="btn btn-secondary">
                            <i class="fas fa-info-circle"></i>
                        </button>
                    </td>

                    <!-- Mobile view: dropdown -->
                    <td class="action-cell-mobile" v-if="rows.length > 0">
                        <button class="action-btn btn btn-secondary dropdown-toggle"
                                type="button"
                                data-bs-toggle="dropdown">
                            <i class="fas fa-ellipsis-v"></i>
                        </button>

                        <ul class="dropdown-menu action-dropdown">
                            <li>
                                <a class="dropdown-item" href="#" @click.prevent="$emit('assign', row)">
                                    <i class="fas fa-handshake"></i> Assign
                                </a>
                            </li>
                            <li>
                                <a class="dropdown-item" href="#" @click.prevent="$emit('edit', row)">
                                    <i class="fas fa-edit"></i> Edit
                                </a>
                            </li>

                            <li>
                                <a class="dropdown-item" href="#" @click.prevent="$emit('delete', row)">
                                    <i class="fas fa-trash-alt"></i> Delete
                                </a>
                            </li>

                            <li>
                                <a class="dropdown-item" href="#" @click.prevent="$emit('view', row)">
                                    <i class="fas fa-info-circle"></i> View
                                </a>
                            </li>
                        </ul>
                    </td>
                </tr>

                <!-- Fallback row when no data -->
                <tr v-if="rows.length === 0">
                    <!-- Use headers?.length safely -->
                    <td :colspan="headers ? headers.length : 1" class="no-items">
                        No items found
                    </td>
                </tr>

            </tbody>
        </table>
    </div>
</template>

<script setup>
    import { toRefs, ref } from "vue"; // You'll need this!
    import { useTableSelection } from '../composables/useTableSelection'

<script setup>defineProps({
  headers: {
    type: Array,
    required: true
  },
  rows: {
    type: Array,
    required: true
  }
})</script>

<style scoped>
    .table-wrapper {
        width: 100%;
        overflow-x: auto;
        background: #ffffff;
        border-radius: 12px;
        position: relative;
        min-height: 400px;
        border: 1px solid #e0e0e0; /* subtle border */
    }
    .book-cover img {
        width: 40px; /* book width */
        height: 60px; /* book height (typical book ratio) */
        object-fit: cover; /* crop image nicely */
        border-radius: 4px; /* small smooth corners */
        display: block;
    }
    .book-stack {
        display: flex;
        flex-direction: column;
        line-height: 1.2;
    }

    .book-title {
        font-weight: 600;
        font-size: 15px;
        color: #212529;
        max-width:230px;
    }

    .book-meta {
        font-size: 13px;
        color: #6c757d;
    }

    .book-meta span:not(:last-child)::after {
        content: " • ";
        margin: 0 4px;
    }

    .book-isbn {
        font-size: 14px;
        color: #9aa0a6;
        magin-top:5px;
    }

    .list-table {
        width: 100%;
        border-collapse: collapse;
        color: #2c3e50; /* deep gray-blue for modern feel */
        font-size: 14px;
        background-color: #fff;
        border-radius: 8px;
        overflow: hidden; /* rounded corners apply to table */
        box-shadow: 0 4px 12px rgba(0,0,0,0.05); /* soft card-like shadow */
    }

    .list-table thead {
        background: linear-gradient(90deg, #f4f6f8, #e9ecef); /* subtle gradient */
        text-transform: uppercase;
        font-size: 12px;
        letter-spacing: 0.6px;
        font-weight: 600;
        color: #495057;
        position:static;
    }

    .list-table th,
    .list-table td {
        padding: 16px 20px;
        text-align: left;
        border-bottom: 1px solid #e9ecef;
    }

    .list-table tbody tr:hover {
        background: #f8f9fa; /* soft hover effect */
        transition: background 0.2s ease-in-out;
    }

    /* Status badge */
    .status-badge {
        padding: 4px 10px;
        border-radius: 20px;
        font-size: 12px;
        text-transform: capitalize;
    }

    .status-badge.active {
        background: #e6f7f1;
        color: #00a86b;
    }

    .status-badge.inactive {
        background: #fdeaea;
        color: #d93025;
    }

    /* Actions hide for mobile as action-cell-mobile were used for mobile */
    .action-cell {
        display: none;
    }

    .action-cell-mobile {
        position: relative;
    }

    .action-cell-mobile:hover .action-dropdown {
        display: block;
        z-index:999;
    }

    .action-btn {
        width: 100%;
        height: 36px;
        font-size: 14px;
        border-radius: 6px;
        color: #333;
        background: transparent;
        border: 1px solid #ddd;
    }

    .action-dropdown {
        width: 160px;
        padding: 6px 0;
        border-radius: 8px;
        border: 1px solid #e0e0e0;
        box-shadow: 0 4px 12px rgba(0,0,0,0.05);
        position: absolute;
        background-color: #fff;
        right: 0;
        display: none;
    }

    .action-dropdown li {
        list-style-type: none;
    }

    .action-dropdown .dropdown-item {
        display: flex;
        align-items: center;
        gap: 8px;
        height: 36px;
        font-size: 13px;
        padding: 0 12px;
        color: #333;
    }

    .action-dropdown .dropdown-item i {
        font-size: 14px;
    }

    .action-dropdown .dropdown-item:hover {
        background-color: #f5f5f5;
    }
    .no-items{
        text-align:center;
    }
    /* Responsive */
    @media (max-width: 576px) {
        .action-btn {
            font-size: 13px;
            height: 34px;
        }

        .action-dropdown {
            width: 140px;
        }

        .action-dropdown .dropdown-item {
            font-size: 14px;
            height: 40px
        }
    }

    @media screen and (min-width: 600px) {

        .table-wrapper{
            overflow:hidden;
        }
        .status-badge{
            font-size:14px;
        }
        
        .action-cell-mobile {
            display: none;
        }
        

        .action-cell {
            display: table-cell;
            flex-direction: row;
            gap: 8px;
        }

        .action-cell button {
            border-radius: 6px;
            font-size: 13px;
            padding: 6px 10px;
            width:40px;
        }
        .btn {
            transition: transform 0.2s ease, box-shadow 0.2s ease;
            background-color:white;
            border:1px solid black;
            color:gray;
            margin:2px;
        }

        /* Hover effect */
        .btn:hover {
            transform: scaleX(1.05); /* widen slightly */
            box-shadow: 0 4px 8px rgba(0,0,0,0.15);
        }

        /* Active (click) effect */
        .btn:active {
            transform: scaleX(0.95); /* compress horizontally */
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
    }
</style>